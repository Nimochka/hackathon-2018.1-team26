const express = require('express');
const socketIO = require('socket.io');
const http = require('http');

const app = express();
const server = http.createServer(app);

const io = socketIO(server);

let players_connected = 0;

let pick = {
    Boss: null,
    Tank: null,
    Hunter: null,
    Support: null,
};

io.on('connection', socket => {
    ++players_connected;
    if (players_connected <= 4)
        socket.emit('connect:success');
    else
        socket.emit('connect:failure');

    socket.on('request:player:pick', () => socket.emit('response:character:pick', pick));
    socket.on('request:player:tick', data => socket.broadcast.emit('response:player:tick', data));
    socket.on('request:player:changehealth', data => socket.broadcast.emit('response:player:changehealth', data));
    socket.on('request:player:shot', data => socket.broadcast.emit('response:player:shot', data));

    socket.on('request:character:select', data => pickCharacter(data));

    socket.on('disconnect', () => {
        --players_connected;
        unpickCharacter(socket.id);
    });
});

function unpickCharacter(socketId) {
    if (pick.Boss === socketId)
        pick.Boss = null;
    else if (pick.Hunter === socketId)
        pick.Hunter = null;
    else if (pick.Support === socketId)
        pick.Support = null;
    else if (pick.Tank === socketId)
        pick.Tank = null;
}

function pickCharacter(data) {
    unpickCharacter(data.SocketId);
    if (data.Character === "Boss") {
        if (pick.Boss == null)
            pick.Boss = data.SocketId;
    }
    else if (data.Character === "Tank") {
        if (pick.Tank == null)
            pick.Tank = data.SocketId;
    }
    else if (data.Character === "Hunter") {
        if (pick.Hunter == null)
            pick.Hunter = data.SocketId;
    }
    else if (data.Character === "Support") {
        if (pick.Support == null)
            pick.Support = data.SocketId;
    }
    io.emit('response:character:pick', pick);
    if (pick.Boss != null && pick.Tank != null && pick.Support != null && pick.Hunter != null)
        io.emit('response:game:start');
}

server.listen(3000, function () {
    console.log('Listening on 3000');
});