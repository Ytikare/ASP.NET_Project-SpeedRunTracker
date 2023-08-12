(function a() {
    const selectElement = document.getElementById("userNameSuggetions");
    const usernameInput = document.getElementById("usernameInput");
    const button = document.getElementById("loadUsers");

    button.addEventListener('click', (e) => {
        e.preventDefault();
        e.stopPropagation();

        let strg = usernameInput.value;

        selectElement.innerText = '';

        fetch(`https://localhost:7036/api/users/${strg}`)
            .then(res => {
                if (res.status == 200) {
                    return res.json();
                }
                throw Error(`${res.status}`)
            })
            .then(data =>
            {
                if (!$.trim(data)) {
                    return;
                }

                let initialGameOptEl = document.createElement('option');
                initialGameOptEl.textContent = '--Choose user--';
                initialGameOptEl.value = 0;

                selectElement.appendChild(initialGameOptEl);

                data.forEach(el => {
                    let optionElement = document.createElement('option');

                    optionElement.textContent = el['username'];

                    optionElement.value = el['id'];

                    selectElement.appendChild(optionElement);
                })
            }).catch((err) => {
                console.log(err.message);
            })
    })

})()