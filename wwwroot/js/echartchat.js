"use strict";
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Debug)
    .build();
var user = "";
var chartDom = document.getElementById('main');
var myChart = window.echarts.init(chartDom);

//对应 IChatClient 里的方法签名
connection.on("GetMyId", function (data) {
    user = data.userId;//SignalR返回的数据字段开头是小写
    console.log(user);
});
connection.on("ReceiveMessage", function (data) {
    console.log(data.userId + data.context);
});

connection.on("EchartsMessage", function (data) {
    console.log(data);
    var option = {
        series: [{
            data: data
        }]
    };
    myChart.setOption(option);//更新Echarts数据
});

connection.start().then(function () {
    console.log("服务器已连接");
}).catch(function (err) {
    return console.error(err.toString());
});