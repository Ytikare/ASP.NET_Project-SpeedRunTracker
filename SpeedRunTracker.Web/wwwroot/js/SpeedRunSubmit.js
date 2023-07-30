(function e() {
    const searchButton = document.getElementById('loadGames');
    const gameInput = document.getElementById('gameTitleInput');
    const gameTitleSelect = document.getElementById('gameTitleSelect');
    const gameCategotySelect = document.getElementById('gameCategorySelect');

    searchButton.addEventListener('click', (e) => {
        e.preventDefault();
        e.stopPropagation();

        let strg = gameInput.value;

        gameTitleSelect.innerHTML = '';
        gameCategotySelect.innerHTML = '';

        fetch(`https://localhost:7036/api/games/${strg}`)
            .then(response => {
                if (response.status == 200) {
                    return response.json();
                }
                throw Error(`${response.status}`);
            }).then(data => {
                if (!$.trim(data)) {
                    return;
                }
                let initialGameOptEl = document.createElement('option');
                initialGameOptEl.textContent = '--Choose game title--';
                initialGameOptEl.value = 0;

                initialGameOptEl.addEventListener('click', () => {
                    gameCategotySelect.innerHTML = '';
                })

                gameTitleSelect.appendChild(initialGameOptEl);

                data.forEach(el => {
                    let optionElement = document.createElement('option');

                    optionElement.textContent = el['gameTitle'];

                    optionElement.value = el['id'];

                    optionElement.addEventListener("click", (ev) => {
                        ev.stopPropagation();
                        gameInput.value = ev.target.textContent;

                        const gameId = ev.target.value;

                        fetch(`https://localhost:7036/api/category/${gameId}`)
                            .then(response => {
                                if (response.status == 200) {
                                    return response.json();
                                }
                                throw Error(`${response.status}`);
                            }).then(data => {

                                let initialCategoryOptEle = document.createElement('option')
                                initialCategoryOptEle.textContent = '--Choose category--';
                                initialCategoryOptEle.value = 0;

                                data.forEach(el => {
                                    let optEl = document.createElement('option');

                                    optEl.textContent = el['category'];

                                    optEl.value = el['id'];

                                    gameCategotySelect.appendChild(optEl);
                                }
                            })).catch((err) => {
                                console.log(err.message);
                            });
                    })
                    gameTitleSelect.appendChild(optionElement);
                })
            }).catch((err) => {
                console.log(err.message);
            })
    })
})()