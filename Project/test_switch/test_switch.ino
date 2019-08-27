int const InputPin = 12; // スイッチからの入力を受け取るPIN番号
bool IsPush = false; // すでに一度押しているか

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(InputPin, INPUT); // 与えられたPIN番号がInputなのかOutputなのかを指定
  digitalWrite(InputPin, HIGH); //内部プルアップ抵抗を有効にする
}

void loop() {
  if( digitalRead(InputPin) == LOW ){
    if(!IsPush){
      Serial.println("Push");
    }
    IsPush = true;
  }else{
    IsPush = false;
  }
}
