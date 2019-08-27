// websocket
var ws   = require ('ws').Server;

// ドローン用のライブラリ
var drone = require('rolling-spider');

// サーバーのセットアップ
var drone_server = new ws ({port: 8000});

// ドローンを指定
var mambo = new drone({uuid:"5bcb81e0238745f3a4dda0cd26d77f6e"});

// ドローンのセットアップ
function set_up_mambo(){
  mambo.connect( () => {                       
    mambo.setup( () => {                       
      mambo.flatTrim();                        
      mambo.startPing();                       
      mambo.flatTrim();                        
      mambo.ACTIVE = true;                     
    });
  });
}

// 1号機用のwebSocket
drone_server.on ('connection', function (ws) {
    ws.on ('message', function (message) {
	    // ドローンに接続
     	if( message == "Connect"){
        	set_up_mambo();
    	}

    	// 離陸
	    if( message == "TakeOff"){
	      	mambo.takeoff();
	    }

	     // 体験を終了させ着陸させる
	    if( message == "Land"){
	      	mambo.land();
	    }
	});
});

