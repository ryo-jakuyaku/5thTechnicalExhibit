// WebSocket関連を作成
// wsライブラリを読み込み
var ws = require('ws').Server;

// 接続元のポート番号を設定
var port_number = 8000;

// サーバソケットを作成
var socket_server = new ws({port:port_number});

// 問題ないかを確認するためのログ表示
console.log("websocket server created");

// ポート設定
socket_server.on('connection', function(ws) {   
	ws.on('message', function(message) {
        if(message == "Hellow Node"){
          console.log('Receive is Hellow Node');
          ws.send("Hellow Unity");
      }
    });

	// 接続が切れた際の関数
    ws.on('close', function() {
        console.log('disconnected...');
    });
});
