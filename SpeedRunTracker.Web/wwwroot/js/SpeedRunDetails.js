(function e() {
    const el = document.querySelector('#infoBtn');

    el.addEventListener('click', (e) => {
        if (false == confirm('Are you sure you want to verify this run?')) {
            e.preventDefault();
            return
        } 
    })
})()