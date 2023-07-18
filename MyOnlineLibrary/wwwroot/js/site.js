let old = $('.card').get(0);
$('.card').click(function () {
    if (old != null && $(old).hasClass('open'))
        $(old).toggleClass('open');
    $(this).toggleClass('open');
    old = this;

})

const searchContainerEl = document.querySelector(".search-container");
const closeBtn = document.querySelector(".fa-times");

searchContainerEl.addEventListener("click", () => {
    searchContainerEl.classList.add("active");
});
closeBtn.addEventListener("click", (event) => {
    event.stopPropagation();
    searchContainerEl.classList.remove("active");
});
