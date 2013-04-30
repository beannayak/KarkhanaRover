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
        indexA = valueFromComputer[7];
        if (indexA > currentDeep){
          currentDeep ++;
        }
        
        rules[indexA].distG = valueFromComputer[1];
        rules[indexA].distL = valueFromComputer[2];
        rules[indexA].tempG = valueFromComputer[3];
        rules[indexA].tempL = valueFromComputer[4];
        rules[indexA].colour = valueFromComputer[5];
        rules[indexA].enabled = valueFromComputer[6];

        for (int x=0; x<=4; x++){
          direct[indexA].directionL[x] = valueFromComputer[8 + x * 2];
          direct[indexA].duration[x] = valueFromComputer[9 + x * 2];
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
  for (int x=0; x<=currentDeep; x++){
    flag = true;
    if (rules[x].enabled == false) { continue; }
    
    if (rules[x].tempG != 255){
      if (tempSensor < rules[x].tempG){
        flag = false;
      }
    }
    
    if (rules[x].tempL != 255){
      if (tempSensor > rules[x].tempL){
        flag = false;
      }
    }  
    
    if (rules[x].distG != 255){
     if ( distSensor < rules[x].distG){
        flag = false;
     }
    }
    
    if (rules[x].distL != 255){
     if ( distSensor > rules[x].distL){
      flag = false;
     }
    }
    if (rules[x].colour != -1){
      if (rules[x].colour != colourSensor){
        flag = false;
      }
    }
    if (flag){
      defaultMoves = false;
      
      for (int y=0; y<=4; y++){
        if (direct[x].directionL[y] != -1){
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
