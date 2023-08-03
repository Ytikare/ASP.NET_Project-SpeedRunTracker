(function e() {

    const cardElement = document.getElementById('speedrunCardBody');

    fetch(`https://localhost:7036/api/speedrun`)
        .then(response => {
            if (response.status == 200) {
                return response.json();
            }
            throw Error(response.status);
        }).then(data => {
            if (!$.trim(data)) {
                return;
            }

            data.forEach(el => {
                cardElement.innerHTML += `<div class="container mb-3 row">
                            <div class="hidden col-md-auto text-center">
                                <a class="align-self-end" href="/Games/Titanfall 2">
                                    <img class="object-fit-container" alt="image alt" src="${el[`gameImageUrl`]}" height="100" width="72" />
                                </a>
                            </div >
                            <div class="col">
                                <table class="table">
                                  <thead>
                                    <tr>
                                      <th scope="col">${el[`gameTitle`]}</th>
                                      <th scope="col"></th>
                                      <th class="text-right" scope="col">${el[`speedRunnerName`]}</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr class="table-secondary">
                                      <td>${el[`category`]}</td>
                                      <td>${el[`submitionDate`]}</td>
                                      <td>${el[`duration`]}</td>
                                    </tr>
                                  </tbody>
                                </table>
                          </div>
                          <div class="col-3 text-center align-self-center">
                              <a href="/SpeedRuns/Details/?speedRunId=${el[`id`]}" type="button" class="text-warning-emphasis btn btn-warning">Check speedrun</a>
                          </div>
                      </div >`
            });
        })
        .catch((err) => {
            console.log(err.message);
        });
})()