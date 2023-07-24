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



    function ConfirmDelete() {
        let text = "Press a button!\nEither OK or Cancel.";
    if (confirm(text) == true) {
        text = "You pressed OK!";
  } else {
        text = "You canceled!";
  }
    document.getElementById("del").innerHTML = text;
}

