const express = require('express');
const socketIO = require('socket.io');
const http = require('http');

const app = express();
const server = http.createServer(app);

const io = socketIO(server);

let players_connected = 0;

io.on('connection', socket => {
    ++players_connected;
    if (players_connected <= 4)
        socket.emit('connect:success');
    else
        socket.emit('connect:failure');

    console.log(`player connected ${socket.id}`);

    socket.on('request:player:tick', data => socket.broadcast.emit('response:player:tick', data));
    socket.on('request:player:changehealth', data => socket.broadcast.emit('response:player:changehealth', data));
    socket.on('request:player:shot', data => socket.broadcast.emit('response:player:shot', data));

    socket.on('disconnect', () => {
        --players_connected;
    });
});

server.listen(3000, function () {
    console.log('Listening on 3000');
});