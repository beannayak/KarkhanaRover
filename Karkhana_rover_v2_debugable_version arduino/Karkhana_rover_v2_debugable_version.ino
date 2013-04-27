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
  char deep;
} myRule;

myRule rules[50];
myDirection direct[50];
char currentDeep = -1;
boolean flag = true;
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
}

char debugFlag = false;

void loop(){
  char r;
  defaultMoves = true;
  /******************** read from computer **************/
  if (Serial.available()){
    r = Serial.read();
    Serial.println (r);
    if (r == '&') {
      Serial.println ("value reseted");
      index = 0;
    } else {
      valueFromComputer[index] = r;
      index ++;
    }
  }
  /*****************************************************/
  
  /************************ check the read value ********/
  if (index == 18){
    index = 0;
    switch (valueFromComputer[0]){
      case 'p':
      case 'P':
        Serial.print ("KarkhanaRover");
        break;
        
      case 'm':
      case 'M':
        debugFlag = true;
        
        defaultDirection = valueFromComputer[1];
        break;
        
      case 'c':
      case 'C':
        debugFlag = true;
        
        if (debugFlag) {
          Serial.println ("value of c checked");
          for (int i=0; i<=17; i++){
            Serial.print (valueFromComputer[i]);
          }
        }
        
        indexA = valueFromComputer[7];
        if (indexA > currentDeep){
          currentDeep ++;
          if (debugFlag) {
            Serial.print ("currentDeep is: "); Serial.println (currentDeep, DEC);
          }
        }
        
        rules[indexA].distG = valueFromComputer[1];
        rules[indexA].distL = valueFromComputer[2];
        rules[indexA].tempG = valueFromComputer[3];
        rules[indexA].tempL = valueFromComputer[4];
        rules[indexA].colour = valueFromComputer[5];
        rules[indexA].enabled = valueFromComputer[6];

        if (debugFlag){
          Serial.print ("indexA is: "); Serial.println (indexA, DEC);
          Serial.print ("Enabled is: "); Serial.println (rules[indexA].enabled, DEC);
        }
        
        for (int x=0; x<=4; x++){
          direct[indexA].directionL[x] = valueFromComputer[8 + x * 2];
          direct[indexA].duration[x] = valueFromComputer[9 + x * 2];
          if (debugFlag){
            Serial.print ("Duration of index: ");
            Serial.print (indexA, DEC);
            Serial.print (" and value: ");
            Serial.print (x, DEC);
            Serial.print (" is: ");
            Serial.println (direct[indexA].duration[x], DEC);
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
  distSensor = getDistance();
  colourSensor = getColour();
  /**********************************************************/
  
  /**************************check rules ***********************/
  if (debugFlag) {
    Serial.print ("Current Deep is: ");
    Serial.println (currentDeep, DEC);
  }
  for (int x=0; x<=currentDeep; x++){
    flag = true;
    if (rules[x].enabled == false) { continue; }
    Serial.println ("testing");
    if (rules[x].tempG != 255){
      if (tempSensor < rules[x].tempG){
        flag = false;
        if (debugFlag){
          Serial.println ("flag falsed Tg");
        }
      }
    }
    
    if (rules[x].tempL != 255){
      if (tempSensor > rules[x].tempL){
        flag = false;
        if (debugFlag) {
          Serial.println ("flag falsed Tl");
        }
      }
    }  
    
    Serial.print ("distG is: "); Serial.println (rules[x].distG, DEC);
    if (rules[x].distG != 255){
     if ( distSensor < rules[x].distG){
        flag = false;
        if (debugFlag) {
          Serial.println ("flag falsed dg");
        }
     }
    }
    Serial.print ("distL is: "); Serial.println (rules[x].distL, DEC);
    if (rules[x].distL != 255){
     if ( distSensor > rules[x].distL){
      flag = false;
      if (debugFlag) {
        Serial.println ("flag falsed dl");
      }
     }
    }
    if (rules[x].colour != -1){
      if (rules[x].colour != colourSensor){
        flag = false;
        if (debugFlag){
          Serial.println ("flag falsed c");
        }
      }
    }
    if (flag){
      defaultMoves = false;
      if (debugFlag){
        Serial.println ("kehi kam bhayo");
      }
      
      for (int y=0; y<=4; y++){
        if (direct[x].directionL[y] != -1){
          if (debugFlag){
            Serial.print("robot dir:");
            Serial.print (direct[x].directionL[y]);
            Serial.print (" robot Duration: "); 
            Serial.println (direct[x].duration[y], DEC);
          }
          
          moveRobot(direct[x].directionL[y]);
          
          /****************creating delay while still testing for serial inputs **************************/
          delayed = 0;
          while (delayed <= direct[x].duration[y]){
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
  }
  
  /***********************************************************************************************************
  
  /***************************default moves********************/
  if (defaultMoves){
    if (debugFlag){
      Serial.print ("robot moving in default direction of: ");
      Serial.println (defaultDirection);
    }
    moveRobot(defaultDirection);
  }
  /**********************************************************/
}

//******************Sensors value reading functions *********/
unsigned char getTemp(){
  unsigned char a = 25;
  return a;
}

unsigned char getDistance(){
  unsigned char a = 15;
  return a;
}

unsigned char getColour(){
  return 'b';
}
/**************motorControl abstraction***************/
void moveRobot(char Direction){
//  Serial.print ("robot Moved: ");
//  Serial.println (Direction);
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
