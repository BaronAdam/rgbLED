#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 6
#define PIN_2 2

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
//   NEO_RGBW    Pixels are wired for RGBW bitstream (NeoPixel RGBW products)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(60, PIN, NEO_GRB + NEO_KHZ800);
Adafruit_NeoPixel strip2 = Adafruit_NeoPixel(58, PIN_2, NEO_GRB + NEO_KHZ800);


// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

int brightness = 45;
int speedVal = 15;

void setup() {
  // This is for Trinket 5V 16MHz, you can remove these three lines if you are not using a Trinket
//  #if defined (__AVR_ATtiny85__)
//    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
//  #endif
  // End of trinket special code

  Serial.begin(9600);
  strip.begin();
  strip.setBrightness(brightness);
  strip.show(); // Initialize all pixels to 'off'
  strip2.begin();
  strip2.setBrightness(brightness / 2);
  strip2.show(); // Initialize all pixels to 'off'
}

void handleSerial();
void functionSelector();
int Red, Green, Blue;

void loop() {
  // Some example procedures showing how to display to the pixels:
//  colorWipe(strip.Color(255, 0, 0), 10); // Red
//  colorWipe(strip.Color(0, 255, 0), 10); // Green
//  colorWipe(strip.Color(0, 0, 255), 10); // Blue

//  rainbow(10);
//  rainbowCycle(10);
  handleSerial();
  functionSelector();
}

int selectedFunction = 0;

void functionSelector() {
  switch (selectedFunction){
    case 0:
      rainbowCycle(speedVal);
//      rainbowCycle2(15);
    break;
    case 1:
      colorWipe(strip.Color(255, 0, 0), 1);
      colorWipe2(strip.Color(255, 0, 0), 1);
    break;
    case 2:
      colorWipe(strip.Color(0, 255, 0), 1);
      colorWipe2(strip.Color(0, 255, 0), 1);
    break;
    case 3:
      colorWipe(strip.Color(0, 0, 255), 1);
      colorWipe2(strip.Color(0, 0, 255), 1);
    break;
    case 4:
      rainbow(speedVal);
    break;
    case 5:
      colorWipe(strip.Color(255, 255, 255), 1);
      colorWipe2(strip.Color(255, 255, 255), 1);
    break;
    case 6:
      colorWipe(strip.Color(Red, Green, Blue), 1);
      colorWipe2(strip2.Color(Red, Green, Blue), 1);
    break;
  }
}

// Fill the dots one after the other with a color
void colorWipe(uint32_t c, uint8_t wait) {
  for(uint16_t i=0; i<strip.numPixels(); i++) {
    strip.setPixelColor(i, c);
    strip.show();
    delay(wait);
  }
}

void colorWipe2(uint32_t c, uint8_t wait) {
  for(uint16_t i=2; i<strip2.numPixels(); i++) {
    strip2.setPixelColor(i, c);
    strip2.show();
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

uint32_t Wheel2(byte WheelPos) {
  WheelPos = 255 - WheelPos;
  if(WheelPos < 85) {
    return strip2.Color(255 - WheelPos * 3, 0, WheelPos * 3);
  }
  if(WheelPos < 170) {
    WheelPos -= 85;
    return strip2.Color(0, WheelPos * 3, 255 - WheelPos * 3);
  }
  WheelPos -= 170;
  return strip2.Color(WheelPos * 3, 255 - WheelPos * 3, 0);
}

void rainbow(uint8_t wait) {
  uint16_t i, j;

  for(j=0; j<256; j++) {
    for(i=0; i<strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel2((i+j) & 255));
      if (i < strip2.numPixels() && i > 1) {
        strip2.setPixelColor(i, Wheel((i+j) & 255));
      }
    }
    strip.show();
    strip2.show();
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

// Slightly different, this makes the rainbow equally distributed throughout
void rainbowCycle(uint8_t wait) {
  uint16_t i, j;
  for(j=0; j<256; j++) { // 5 cycles of all colors on wheel
    for(i=0; i< strip.numPixels(); i++) {
      strip.setPixelColor(i, Wheel(((i * 256 / strip.numPixels()) + j) & 255));
      if (i < strip2.numPixels() && i > 1) {
        strip2.setPixelColor(i, Wheel2(((i * 256 / strip2.numPixels()) + j) & 255));
      }
    }
    strip.show();
    strip2.show();
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
      strip2.setBrightness(brightness / 2);
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
