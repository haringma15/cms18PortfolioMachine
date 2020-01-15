int pinGreen = 10;
int pinYellow = 11;
int inByte = 0;

void setup() {
  Serial.begin(9600);
  while (!Serial) { ; }
  pinMode(pinGreen, OUTPUT);
  pinMode(pinYellow, OUTPUT);
}

void loop() {
  if (Serial.available()) {
    inByte = Serial.read();
    digitalWrite(pinGreen, LOW);
    digitalWrite(pinYellow, LOW);
  }
  if (inByte == 48) {
    digitalWrite(pinGreen, LOW);
    digitalWrite(pinYellow, HIGH);
    delay(10);
  } else if (inByte == 49) {
    digitalWrite(pinGreen, HIGH);
    digitalWrite(pinYellow, LOW);
    delay(10);
  }
}
