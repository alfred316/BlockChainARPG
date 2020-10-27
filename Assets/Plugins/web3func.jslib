mergeInto(LibraryManager.library, {

  ConnectToMetaMask: function (objectName, callback) {
    var parsedObjectName  = Pointer_stringify(objectName);
    var parsedCallback    = Pointer_stringify(callback);
    ReactUnityWebGL.ConnectToMetaMask(parsedObjectName, parsedCallback);
  },

  // @stakeAmount: plain integer
  ApproveUSDC: function(objectName, callback, stakeAmount) {
    var parsedObjectName = Pointer_stringify(objectName);
    var parsedCallback = Pointer_stringify(callback);
    // console.log('RECEIVED STAKE AMOUNT: ' + stakeAmount);
    stakeAmount = Pointer_stringify(stakeAmount);
    ReactUnityWebGL.ApproveUSDC(parsedObjectName, parsedCallback, stakeAmount);
  },

  StakeEntry: function(objectName, callback, stakeAmount) {
    var parsedObjectName = Pointer_stringify(objectName);
    var parsedCallback = Pointer_stringify(callback);
    stakeAmount = Pointer_stringify(stakeAmount);

    ReactUnityWebGL.StakeEntry(parsedObjectName, parsedCallback, stakeAmount);
  }

  // SelectLandTransaction: function(objectName, callback, landNum) {
  //   var parsedObjectName = Pointer_stringify(objectName);
  //   var parsedCallback = Pointer_stringify(callback);
  //   var parsedLandNum = Pointer_stringify(landNum);
  //   var account = window.accounts[0];
  //   var landID = web3.utils.sha3(parsedLandNum);
  //   console.log("LAND ID: " + landNum);
  //   // window.web3.eth.personal.sign(window.web3.utils.utf8ToHex("Land: " + landNum), account) / outdated
  //   window.web3.eth.personal.sign(landID, account)
  //     .then(function(result) {
  //       console.log(result);
  //       console.log("Signature Returned");
  //       unityInstance.SendMessage(parsedObjectName, parsedCallback, "Land Issued");
  //     });
      // .on('error', function(error) {
      //   console.log('ERROR: ');
      //   console.log(error);
      //   unityInstance.SendMessage(parsedObjectName, parsedCallback, "ERROR: HELLO FROM SELECT LAND TRANSACTION");
      // })
      // .on('receipt', function(receipt) {
      //   console.log('RECEIPT: ');
      //   console.log(receipt);
      //   unityInstance.SendMessage(parsedObjectName, parsedCallback, "RECEIPT: HELLO FROM SELECT LAND TRANSACTION");
      // })
  // }
});