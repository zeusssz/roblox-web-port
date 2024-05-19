const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const port = 3000;

app.use(cors());
app.use(bodyParser.json());

let gameData = []; // To store game data

app.post('/api/data', (req, res) => {
    const data = req.body;
    gameData.push(data);
    res.send('Data received');
});

app.get('/api/data', (req, res) => {
    res.json(gameData);
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
