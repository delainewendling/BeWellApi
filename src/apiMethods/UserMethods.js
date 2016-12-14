import axios from 'axios';

export function registerUser (user) {
    axios.post('http://bewellapi20161212034630.azurewebsites.net/account/RegisterJson')
    .then(response =>{
      console.log("response data", response);
    })
    .catch(error=>{
      console.log("there was an error", error);
    })
}

export function loginUser (user) {
    axios.post('http://bewellapi20161212034630.azurewebsites.net/account/LoginJson')
    .then(response =>{
      console.log("response data", response);
    })
    .catch(error=>{
      console.log("there was an error", error);
    })
}
