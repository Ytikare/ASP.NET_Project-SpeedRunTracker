(function e() {
    let elements = document.querySelectorAll('.btn-warning')

    elements.forEach(el => {
        el.addEventListener('click', (e) => {
            if (false == confirm('Are you sure you want to remove moderation rights from this user?')) {
                e.preventDefault();
                return;
            }
        })
    })
})()