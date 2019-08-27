// WebSocket関連を作成
// wsライブラリを読み込み
var ws = require('ws').Server;

// 接続元のポート番号を設定
var iphone_port_number = 4000;
var pc_port_number = 8000;

// サーバソケットを作成
var iphone_socket_server = new ws({port:iphone_port_number});
var pc_socket_server = new ws({port:pc_port_number});

// iPhone側のキャラクターの場所
var charactor_trasform_from_iphone;

// iPhoneが接続されたか
var IsConnected = false;

// 問題ないかを確認するためのログ表示
console.log("websocket server created");

// iPhone側のポート設定
iphone_socket_server.on('connection', function(ws) {   
	ws.on('message', function(message) {

    // PC側にキャラクターのActiveを通知
    IsConnected = true;

    // 同期する座標
    charactor_trasform_from_iphone = message;
    console.log(charactor_trasform_from_iphone);
  });

	// 接続が切れた際の関数
  ws.on('close', function() {
    console.log('disconnected...');
  });
});


// PC側のポート設定
pc_socket_server.on('connection', function(ws) {   
  ws.on('message', function(message) {
    // PC側にキャラクターを生成
    if(IsConnected){
      ws.send("Connect"); 
    }

    // PC側にキャラクターの座標を通知
    ws.send(charactor_trasform_from_iphone);
  });

  // 一定時間おきに送信するので先にiPhoneを接続しておく
  setInterval(function() {
    ws.send(charactor_trasform_from_iphone);
    }, 100);

  // 接続が切れた際の関数
  ws.on('close', function() {
    console.log('disconnected...');
  });
});
