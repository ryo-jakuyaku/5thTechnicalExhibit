// BlueToothのライブラリ
var noble = require('noble');
var knownDevices = [];
 
if (noble.state === 'poweredOn') {
  start()
} else {
  noble.on('stateChange', start);
}
 
function start () {
  noble.startScanning();
 
  noble.on('discover', function(peripheral) {
 
    console.log(
      "------------------------------ \n",
      peripheral.uuid,peripheral.advertisement.localName);
    if(peripheral.advertisement.localName && peripheral.advertisement.localName.indexOf('Maclan_') === 0){
      console.log(peripheral.advertisement.manufacturerData.toString('hex'));
    }
 
    var details = {
      name: peripheral.advertisement.localName,
      uuid: peripheral.uuid,
      rssi: peripheral.rssi
    };
 
    knownDevices.push(details);
    console.log(knownDevices.length + ': ' + details.name + ' (' + details.uuid + '), RSSI ' + details.rssi);
  });
}