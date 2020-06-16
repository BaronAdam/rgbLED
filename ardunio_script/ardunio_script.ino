#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 6

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
//   NEO_RGBW    Pixels are wired for RGBW bitstream (NeoPixel RGBW products)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(60, PIN, NEO_GRB + NEO_KHZ800);

int brightness = 50;
int speedVal = 15;

void setup() {

  Serial.begin(9600);
  strip.begin();
  strip.setBrightness(brightness);
  strip.show(); 
}

void handleSerial();
void functionSelector();
void dualColor();
int Red, Green, Blue, r1, g1, b1, r2, g2, b2;

void loop() {

  handleSerial();
  functionSelector();
}

int selectedFunction = 0;

void functionSelector() {
  switch (selectedFunction){
    case 0:
      rainbowCycle(speedVal);
    break;
    case 1:
      colorWipe(strip.Color(255, 0, 0), 1);
    break;
    case 2:
      colorWipe(strip.Color(0, 255, 0), 1);
    break;
    case 3:
      colorWipe(strip.Color(0, 0, 255), 1);
    break;
    case 4:
      rainbow(speedVal);
    break;
    case 5:
      colorWipe(strip.Color(255, 255, 255), 1);
    break;
    case 6:
      colorWipe(strip.Color(Red, Green, Blue), 1);
    break;
    case 7:
      dualColor(strip.Color(r1,g1,b1), strip.Color(r2,b2,b2), 1);
    break;
  }
}

void dualColor(uint32_t c2, uint32_t c1, uint8_t wait) {
  for (uint16_t i=0; i < strip.numPixels() * 0.5; i++) {
    strip.setPixelColor(i, c1);
    strip.show();
    delay(wait);
  }
  for (uint16_t i = strip.numPixels() * 0.5; i < strip.numPixels(); i++) {
    strip.setPixelColor(i, c2);
    strip.show();
    delay(wait);
  }
}

void colorWipe(uint32_t c, uint8_t wait) {
  for(uint16_t i=0; i<strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
    strip.show();
    delay(wait);
  }
}

uint32_t Wheel(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if(WheelPos < 85) {
    return strip.Color(255 - WheelPos * 3, 0, WheelPos * 3);
  }
  if(WheelPos < 170) {
    WheelPos -= 85;
    return strip.Color(0, WheelPos * 3, 255 - WheelPos * 3);
  }
  WheelPos -= 170;
  return strip.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}


void rainbow(uint8_t wait) {
  uint16_t i, j;

  for(j=0; j<256; j++) {
    for(i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel((i+j) & 255));
    }
    strip.show();
    delay(wait);
  }
}

void setB(int b) { 
  brightness += b;
  
  if (brightness > 100) {
    brightness = 100;
  }
  else if (brightness < 0) {
    brightness = 0;
  }
}

void setS(int b) { 
  speedVal += b;
  
  if (speedVal > 30) {
    speedVal = 30;
  }
  else if (speedVal < 0) {
    speedVal = 0;
  }
}

void rainbowCycle(uint8_t wait) {
  uint16_t i, j;
  for(j=0; j<256; j++) { // 5 cycles of all colors on wheel
    for(i=0; i< strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel(((i * 256 / strip.numPixels()) + j) & 255));
    }
    strip.show();
    delay(wait);
  }
}

void handleSerial() {
 if (Serial.available() >0) {
  while (Serial.available() > 0) {
   char incomingCharacter = Serial.read();
   
   switch (incomingCharacter) {
     case 'R':
      selectedFunction = 1;
      break;
     case 'G':
      selectedFunction = 2;
      break;
     case 'B':
      selectedFunction = 3;
      break;
     case 'r':
      selectedFunction = 0;
      break;
     case 't':
      selectedFunction = 4;
      break;
     case 'W':
      selectedFunction = 5;
      break;
     case 'C':
      while(!Serial.available()){}
      Red = Serial.read();
      while(!Serial.available()){}
      Green = Serial.read();
      while(!Serial.available()){}
      Blue = Serial.read();
      selectedFunction = 6;
      break;
    case 'd':
      while(!Serial.available()){}
      r1 = Serial.read();
      while(!Serial.available()){}
      g1 = Serial.read();
      while(!Serial.available()){}
      b1 = Serial.read();
      while(!Serial.available()){}
      r2 = Serial.read();
      while(!Serial.available()){}
      g2 = Serial.read();
      while(!Serial.available()){}
      b2 = Serial.read();
      selectedFunction = 7;
      break;
    case '[':
      setS(5);
      break;
    case ']':
      setS(-5);
      break;
    case '*':
      speedVal = 15;
      break;
    case 'b':
      while(!Serial.available()){}
      brightness = Serial.read();
      strip.setBrightness(brightness);
      break;
    }
   }
  }
  else {
    setB(-100);
  }
}



// Input a value 0 to 255 to get a color value.
// The colours are a transition r - g - b - back to r.
