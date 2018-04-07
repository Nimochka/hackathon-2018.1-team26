const express = require('express');
const socketIO = require('socket.io');
const http = require('http');

const app = express();
const server = http.createServer(app);

const io = socketIO(server);

io.on('connection', socket => {
    console.log(`player connected ${socket.id}`);

    socket.on('request:player:tick', data => {
        socket.broadcast.emit('response:player:tick', data);
    });

    socket.on('disconnect', () => console.log(`player ${socket.id} disconnected`));
});

server.listen(3000, function () {
    console.log('Listening on 3000');
});