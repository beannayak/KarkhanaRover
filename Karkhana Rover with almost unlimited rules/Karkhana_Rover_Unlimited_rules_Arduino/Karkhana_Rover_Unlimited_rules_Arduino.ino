#include <TimerOne.h>

/**************variables related to roboshield*************/
# define Lp  7    // left motor positive
# define Ln  4    // left motor negative
# define El  5    // left motor enable

# define Rp  8    // right motor positive
# define Rn  12   // right motor negative
# define Er  6    // right motor enable
/**********************************************************/

/*******************Timer initilize for delay ************/
volatile int delayed = 0;

void timerIsr(){
  delayed += 1;
}
/*********************************************************/

/***************variables related to rules*****************/
char valueFromComputer[18];
char defaultDirection = 'x';
char index = 0;
char indexA = 0;
boolean defaultMoves = true;

typedef struct directionNode {
  char directionL[5];
  char duration[5];
} myDirection;

typedef struct ruleNode {
  unsigned char tempG;
  unsigned char tempL;
  unsigned char distG;
  unsigned char distL;
  char colour;
  char enabled;
  struct ruleNode* nextNode;
  struct directionNode* direct;
} myRule;

char currentDeep = -1;
boolean flag = true;
myRule* firstRuleNode = (myRule*) malloc (sizeof(myRule));
myDirection* firstDirectionPointer = (myDirection*) malloc (sizeof(myDirection));

myRule* currentNodePointer = firstRuleNode;
myRule* processingNode = NULL;
/**********************************************************/

/******************* variables related to sensors ************/
unsigned char tempSensor;
unsigned char distSensor;
char colourSensor;
/*************************************************************/

void setup(){
  Timer1.initialize(1000000);
  Timer1.attachInterrupt( timerIsr );
  Serial.begin(9600);
  firstRuleNode->nextNode = NULL;
  firstRuleNode->direct = firstDirectionPointer;
  for (int x=2; x<=12; x++){
    pinMode (x, OUTPUT);
  }
  pinMode (3, INPUT);
  digitalWrite (Er, HIGH);
  digitalWrite (El, HIGH);
}

boolean debugFlag = false;
boolean testFlag = false;

void loop(){
  char r;
  defaultMoves = true;
  /******************** read from computer **************/
  if (Serial.available()){
    r = Serial.read();
    //Serial.println (r);
    if (r == '&') {
      Serial.println ("value reseted");
      index = 0;
      testFlag = false;
    } else {
      valueFromComputer[index] = r;
      index ++;
    }
  }
  /*****************************************************/
  
  /************************ check the read value ********/
  if (index == 18){
    testFlag = true;
    index = 0;
    switch (valueFromComputer[0]){
      case 'p':
      case 'P':
        Serial.print ("KarkhanaRover");
        testFlag = true;
        break;
        
      case 'm':
      case 'M':
        defaultDirection = valueFromComputer[1];
        break;
        
      case 'c':
      case 'C':        
        debugFlag = true;
        
        indexA = valueFromComputer[7];
        if (indexA > currentDeep){
          currentDeep ++;
          myRule* newRuleNode = (myRule*) malloc(sizeof(myRule));
          if (newRuleNode == NULL) {
            //Memory Full do somethin
            debugFlag = false;
            Serial.println ("Memory Full");
            break;  
          }
          
          newRuleNode->distG = valueFromComputer[1];
          newRuleNode->distL = valueFromComputer[2];
          newRuleNode->tempG = valueFromComputer[3];
          newRuleNode->tempL = valueFromComputer[4];
          newRuleNode->colour = valueFromComputer[5];
          newRuleNode->enabled = valueFromComputer[6];
          currentNodePointer->nextNode = newRuleNode;
          
          myDirection* newDirectionNode = (myDirection*) malloc (sizeof(myDirection));
          for (int x=0; x<=4; x++){
            newDirectionNode->directionL[x] = valueFromComputer[8 + x * 2];
            newDirectionNode->duration[x] = valueFromComputer[9 + x * 2];
          }
          
          currentNodePointer = newRuleNode;
          currentNodePointer->direct = newDirectionNode;
          newRuleNode->nextNode = NULL;
          
          if (debugFlag){
            Serial.println ("distG, distL, tempG, tempL, colour, enabled");
            Serial.print (currentNodePointer->distG, DEC);
            Serial.print (currentNodePointer->distL, DEC);            
            Serial.print (currentNodePointer->tempG, DEC);
            Serial.print (currentNodePointer->tempL, DEC);
            Serial.print (currentNodePointer->colour, DEC);
            Serial.print (currentNodePointer->enabled, DEC);
            for (int x=0; x<=4; x++){
              Serial.print (currentNodePointer->direct->directionL[x], DEC);
              Serial.println (currentNodePointer->direct->duration[x], DEC);
            }
          }
          
        } else {  
          myRule* tempRule = firstRuleNode;
          for (int x=0; x<=indexA; x++){
            tempRule = tempRule->nextNode;
          }
          tempRule->distG = valueFromComputer[1];
          tempRule->distG = valueFromComputer[1];
          tempRule->distL = valueFromComputer[2];
          tempRule->tempG = valueFromComputer[3];
          tempRule->tempL = valueFromComputer[4];
          tempRule->colour = valueFromComputer[5];
          tempRule->enabled = valueFromComputer[6];
          
          for (int x=0; x<=4; x++){
            tempRule->direct->directionL[x] = valueFromComputer[8 + x * 2];
            tempRule->direct->duration[x] = valueFromComputer[9 + x * 2];
          }
        }
        break;
        
      default:
        break;
    }
  }
  /**********************************************************/
  
  /********************* check for sensor values ************/
  tempSensor = getTemp();
  if (testFlag) {
    distSensor = getDistance();
  }
  colourSensor = getColour();
  /**********************************************************/
  
  /**************************check rules ***********************/
  processingNode = firstRuleNode->nextNode;
  for (int x=0; x<=currentDeep; x++){
    flag = true;
    if (processingNode->enabled == false) { continue; }
    if (debugFlag){                         Serial.println ("testing"); }    
    
    if (processingNode->tempG != 255){
      if (tempSensor < processingNode->tempG){
        flag = false;
        if (debugFlag){
          Serial.println ("falsed by tempG");
        }
      }
    }
    
    if (processingNode->tempL != 255){
      if (tempSensor > processingNode->tempL){
        flag = false;
        if (debugFlag){
          Serial.println ("falsed by tempL");
        }
      }
    }  
    
    if (processingNode->distG != 255){
     if ( distSensor < processingNode->distG){
        if (debugFlag){
          Serial.println ("falsed by distG");
        }       
        flag = false;
     }
    }
    
    if (processingNode->distL != 255){
     if ( distSensor > processingNode->distL){
      flag = false;
        if (debugFlag){
          Serial.println ("falsed by distL");
        }      
     }
    }
    
    if (processingNode->colour != -1){
      if (processingNode->colour != colourSensor){
        flag = false;
        if (debugFlag){
          Serial.println ("falsed by tempG");
        }
      }
    }
    
    if (flag){
      defaultMoves = false;
      
      for (int y=0; y<=4; y++){
        if (processingNode->direct->directionL[y] != -1){
          moveRobot(processingNode->direct->directionL[y]);
          if (debugFlag){
            Serial.print ("Robot is moving in direction: ");
            Serial.print (processingNode->direct->directionL[y]);
            Serial.print (" for duration of: ");
            Serial.println (processingNode->direct->duration[y], DEC);
          }
          /****************creating delay while still testing for serial inputs **************************/
          delayed = 0;
          while (delayed <= processingNode->direct->duration[y]){
            if (Serial.available()){
              r = Serial.read();
              if (r == '&') {
                Serial.println ("value reseted");
                index = 0;
              } else {
                valueFromComputer[index] = r;
                index ++;
              }
            }
          }
          /*************************************************************************************************/
        } else {
          break;
        }
      }
    }
    processingNode = processingNode->nextNode;   
  }
  
  /***********************************************************************************************************
  
  /***************************default moves********************/
  if (defaultMoves){
    moveRobot(defaultDirection);
  }
  /**********************************************************/
}

//******************Sensors value reading functions *********/
unsigned char getTemp(){
  int tempAnalogValue = analogRead(A3);
  unsigned int temperature;

  temperature = (5.0 * tempAnalogValue * 100.0)/1024.0;
  return (unsigned char) temperature;
}

unsigned char getDistance(){
  digitalWrite(2,HIGH);
  delayMicroseconds(10);
  digitalWrite(2,LOW);
  int32_t microseconds=pulseIn(3,HIGH);
  if (microseconds > 60000){
    return 255;
  }
  int32_t distance=(34*microseconds)/1000;
  return (unsigned char)distance;
}

char getColour(){
  char colorAnalogValue = analogRead(A2);
  if (colorAnalogValue < 110) {
    return 'w';
  } else {
    return 'b';
  }
}
/**************motorControl abstraction***************/
void moveRobot(char Direction){
  switch (Direction){
    case 'x':                  //Stop
      motorControl (0, 0);
      break;
     
    case 'w':                  //forward
      motorControl (1, 1);
      break;
    
    case 's':                  //backward
      motorControl (2, 2);
      break;
      
    case 'd':                  //right
      motorControl (1, 0);
      break;
     
    case 'a':                  //left
      motorControl (0, 1);
      break;
      
    case 'q':                  //sharp left
      motorControl (2, 1);
      break;
      
    case 'e':                  //sharp right
      motorControl (1, 2);
      break;
      
    case 'z':                  //reverse left
      motorControl (2, 0);
      break;
      
    case 'c':                  //reverse right
      motorControl (0, 2);
      break;
      
    default:
      break;
  }
}
/*********************************************************/

/********** low level motor controling function **********/
void motorControl(int driveL, int driveR) {
  switch (driveL) {    
    case 0:                  // lft STOP
      digitalWrite (Ln,LOW);
      digitalWrite (Lp,LOW);
      break;
      
    case 1:                  // lft FORWARD
      digitalWrite (Ln,HIGH);
      digitalWrite (Lp,LOW);
      break;
      
    case 2:                  // lft REVERSE
      digitalWrite (Ln,LOW);
      digitalWrite (Lp,HIGH);
      break;
      
    default:break;
  } 
  
  switch (driveR) {    
    case 0:                  // rgt STOP
      digitalWrite (Rn,LOW);
      digitalWrite (Rp,LOW);
      break;
      
    case 1:                  // rgt FORWARD
      digitalWrite (Rn,HIGH);
      digitalWrite (Rp,LOW);
      break;
      
    case 2:                  // rgt REVERSE
      digitalWrite (Rn,LOW);
      digitalWrite (Rp,HIGH);
      break;
    
    default:
      break;
  }  
}
/*********************************************************/
