// const saveButton=document.querySelector('#btnsave');
// const titleInput=document.querySelector('#title');
// const descriptionInput=document.querySelector('#description');
// const notescontainer=document.querySelector('.notes_container');
// const deletButton=document.querySelector('#btnDelete')
// const editButton=document.querySelector('#btnEdit')
// function clearForm()
// {
//     titleInput.value='';
//     descriptionInput.value='';
// }
// function displayNotesInForm(note)
// {
//     titleInput.value=note.title;
//     descriptionInput.value=note.description;
//     deletButton.classList.remove('hidden');
//     editButton.classList.remove('hidden');
//     deletButton.setAttribute('data-id',note.id);
//     editButton.setAttribute('data-id',note.id);
// }

const notescontainer = document.querySelector('.notes_container');
function getNoteById(id)
{
    fetch(`https://localhost:7153/api/Trainer/getbyid/${id}`)
    .then(data=>data.json())
    .then(response=>document.writeln(response));
}


function populateForm(id)
{
    getNoteById(id);
    
}

// function addNote(title,description){

//     const body={
//         title:title,
//         description:description,
//         isVisible:true
//     };
//     fetch('https://localhost:7153/api/Trainer/Adddetails',
//     {
//         method:'POST',
//         body:JSON.stringify(body),
//         headers:{
//             "content-type":"application/json"
//         }

//     })
//     .then(data=>data.json())
//     .then(response => {
//         clearForm();
//         displayNotes();
//     });
// }
// function updateNote(title,description){

//     const body={
//         title:title,
//         description:description,
//         isVisible:true
//     };
//     fetch('https://localhost:7132/api/Notes',
//     {
//         method:'PUT',
//         body:JSON.stringify(body),
//         headers:{
//             "content-type":"application/json"
//         }

//     })
//     .then(data=>data.json())
//     .then(response => {
//         clearForm();
//         displayNotes();
//     });
// }

function displayTrainer(trainer)
{
    let allNotes='';
    
    trainer.forEach( note => {
        const noteElement= `
        <div class="note" data-id="${note.user_id}">
            <h2>${note.full_name}</h2>
            <p>${note.email}</p>
            <p>${note.age}</p>
            <p>${note.website}</p>
            <p>${note.password}</p>
            <p>${note.mobile_nummber}</p>
            <p>${note.gender}</p>
        </div>
        `;
        allNotes+=noteElement;
        
    });
    notescontainer.innerHTML= allNotes;
    //add Even listeners

    document.querySelectorAll('.note').forEach(note =>
        note.addEventListener('click',function()
        {
           populateForm(note.user_id);
        }))
}




// saveButton.addEventListener('click',function()
// {
//     addNote(titleInput.value,descriptionInput.value);
// });

// function deleteNode(id)
// {
//     fetch(`https://localhost:7132/api/Notes/${id}`,{
//         method:'DELETE',
//         headers:
//         {
//             "content-type":"application/json"
//         }
//     })
    
//     .then(response => {
//         clearForm();
//         getAllNotes();
//     })

// }
// deletButton.addEventListener('click',function()
// {
//     const id=deletButton.dataset.id;
//     deleteNode(id);
// })
// editButton.addEventListener('click',function()
// {
//     updateNote(id,titleInput.value,descriptionInput.value);
// })



















// const formbutton = document.querySelector('#btnsubmit').value;
// var emailbutton = document.getElementById('#email').value;
// var passbutton = document.getElementById('#password').value;
// var agebutton = document.getElementById('#age').value;
// var gbutton = document.getElementById('#gender').value;
// var webbutton = document.getElementById('#web').value;
// var mobilebutton = document.getElementById('#mobile').value;
// var namebutton = document.getElementById('#fullName').value;

// function addTrainer(full_name,email,password,age,gender,website,phonenumber){
//     const body = {
//         full_name: full_name,
//         password: password,
//         email: email,
//         age: age,
//         gender: gender,
//         mobile_number: phonenumber,
//         website: website 
//     };
//     fetch('https://localhost:7153/api/Trainer/Add',{
//         method: 'POST',
//         body: JSON.stringify(body),
//         headers: {
//             "content-type": "application/json"
//         }
//     })
//     .then(data => data.json())
//     .then(response => console.log(response));
// }

// formbutton.addEventListener('submit',function(){
//     console.log(namebutton);
//     addTrainer(namebutton,emailbutton,passbutton,agebutton,
//         gbutton,webbutton,mobilebutton)
// });


// function addSkills() {
//       let email = localStorage.getItem('email') 
//       email = email.replace(/['‘’"“”]/g, '')
//       let flag = fasle;
//       if(email != null){
//         flag = true
//       }
//       if(flag == true){
//         handleAddSkill();
//       }
//     }
    
    