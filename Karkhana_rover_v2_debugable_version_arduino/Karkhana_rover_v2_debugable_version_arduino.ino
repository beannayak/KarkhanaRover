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

char myDirection[50][5];
char myDuration[50][5];

unsigned char tempG[50];
unsigned char tempL[50];
unsigned char distG[50];
unsigned char distL[50];
char colour[50];
char enabled[50];
char deep[50];

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
  digitalWrite (Er, HIGH);
  digitalWrite (El, HIGH);
}

char debugFlag = false;

void loop(){
  char r;
  defaultMoves = true;
  /******************** read from computer **************/
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
        debugFlag = false;
     
        defaultDirection = valueFromComputer[1];
        break;
        
      case 'c':
      case 'C':
        debugFlag = false;
        
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
        
        distG[indexA] = valueFromComputer[1];
        distL[indexA] = valueFromComputer[2];
        tempG[indexA] = valueFromComputer[3];
        tempL[indexA] = valueFromComputer[4];
        colour[indexA] = valueFromComputer[5];
        enabled[indexA] = valueFromComputer[6];

        if (debugFlag){
          Serial.print ("indexA is: "); Serial.println (indexA, DEC);
          Serial.print ("Enabled is: "); Serial.println (enabled[indexA], DEC);
        }
        
        for (int x=0; x<=4; x++){
          myDirection[indexA][x] = valueFromComputer[8 + x * 2];
          myDuration[indexA][x] = valueFromComputer[9 + x * 2];
          if (debugFlag){
            Serial.print ("Duration of index: ");
            Serial.print (indexA, DEC);
            Serial.print (" and value: ");
            Serial.print (x, DEC);
            Serial.print (" is: ");
            Serial.println (myDuration[indexA][x], DEC);
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
    if (enabled[x] == false) { continue; }
    Serial.println ("testing");
    if (tempG[x] != 255){
      if (tempSensor < tempG[x]){
        flag = false;
        if (debugFlag){
          Serial.println ("flag falsed Tg");
        }
      }
    }
    
    if (tempL[x] != 255){
      if (tempSensor > tempL[x]){
        flag = false;
        if (debugFlag) {
          Serial.println ("flag falsed Tl");
        }
      }
    }  
    
    Serial.print ("distG is: "); Serial.println (distG[x], DEC);
    if (distG[x] != 255){
     if ( distSensor < distG[x]){
        flag = false;
        if (debugFlag) {
          Serial.println ("flag falsed dg");
        }
     }
    }
    Serial.print ("distL is: "); Serial.println (distL[x], DEC);
    if (distL[x] != 255){
     if ( distSensor > distL[x]){
      flag = false;
      if (debugFlag) {
        Serial.println ("flag falsed dl");
      }
     }
    }
    if (colour[x] != -1){
      if (colour[x] != colourSensor){
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
        if (myDirection[x][y] != -1){
          if (debugFlag){
            Serial.print("robot dir:");
            Serial.print (myDirection[x][y]);
            Serial.print (" robot Duration: "); 
            Serial.println (myDuration[x][y], DEC);
          }
          
          moveRobot(myDirection[x][y]);
          
          /****************creating delay while still testing for serial inputs **************************/
          delayed = 0;
          while (delayed <= myDuration[x][y]){
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
  int tempAnalogValue = analogRead(A2);
  unsigned int temperature;

  temperature = (5.0 * tempAnalogValue * 100.0)/1024.0 - 13;
  return (unsigned char) temperature;
}

unsigned char getColour(){
  char colorAnalogValue = analogRead(A3);
  unsigned char retVal;
  if (colorAnalogValue > 150) {
    retVal = 'w';
  } else {
    retVal = 'b';
  }
  return retVal;
}

unsigned char getDistance(){
  digitalWrite(2,HIGH);
  delayMicroseconds(10);
  digitalWrite(2,LOW);
  int32_t microseconds=pulseIn(3,HIGH);
  if (microseconds > 60000){
    return 0;
  }
  int32_t distance=(34*microseconds)/1000;
  return (unsigned char)distance;
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
