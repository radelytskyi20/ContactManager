const form = document.querySelector("form");
const clearButton = document.querySelector("#clearButton");

form.addEventListener("submit", async (event) => {
    event.preventDefault();

    const resume = getResumeData();
    try {
        await axios.post("https://localhost:5003/resumes", resume);
        alert("Resume added successfully!");
        window.location.href = "index.html";

    } catch (e) {
        console.log("Exception", e);
        alert("An error occurred while adding the resume!");
    }
});

clearButton.addEventListener("click", (event) => {
    clearForm();
})

function clearForm() {
    form.elements.nameInput.value = "";
    form.elements.birthDateInput.value = "";
    form.elements.marriedInput.value = "";
    form.elements.phoneInput.value = "";
    form.elements.salaryInput.value = "";
}

function getResumeData() {
    const resume = {
        name: form.elements.nameInput.value,
        birthDate: form.elements.birthDateInput.value,
        married: form.elements.marriedInput.value === "1" ? true : false,
        phone: form.elements.phoneInput.value,
        salary: form.elements.salaryInput.value
    }

    return resume;
}