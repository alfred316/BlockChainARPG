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
});