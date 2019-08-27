int const OutputPin = 12; // スイッチからの入力を受け取るPIN番号
int counter = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(OutputPin, OUTPUT); // 与えられたPIN番号がInputなのかOutputなのかを指定
}

void loop() {
  counter++;
  if(counter > 100){
    counter = 0;
  }
  // 偶数の時のみ電気をつける
  if(counter % 2 == 0){
    digitalWrite(OutputPin, HIGH);
  }else{
    digitalWrite(OutputPin, LOW);
  }

  delay(100);
}
