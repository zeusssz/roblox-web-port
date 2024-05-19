async function getUserInfo() {
            const username = document.getElementById('username').value;
            const response = await fetch(`http://localhost:3000/user/${username}`);
            const data = await response.json();
            document.getElementById('userInfo').textContent = JSON.stringify(data, null, 2);
        }
