const Empdata = [
    {
        firstname: "Mahipal1",
        lastname: "Chavda",
        email: "Mahipal@gmail.com",
        phone: "7984172560",
        gender: "male",
        department: ".Net",
        skills: ["Programming","ProCommunication"],
        about: "hello",
        id:1
    }, 
    {
        firstname: "manish1",
        lastname: "yadav",
        email: "manish@gmail.com",
        phone: "9104136213",
        gender: "male",
        department: "php",
        skills: ["Programming"],
        about: "this is good person",
        id:2
    }, {
        firstname: "Mahipal2",
        lastname: "Chavda",
        email: "Mahipal@gmail.com",
        phone: "7984172560",
        gender: "male",
        department: ".Net",
        skills: ["Programming"],
        about: "hello",
        id:3
    }, 
    {
        firstname: "manish2",
        lastname: "yadav",
        email: "manish@gmail.com",
        phone: "9104136213",
        gender: "male",
        department: "php",
        skills: ["Programming"],
        about: "this is good person",
        id:4
    }, {
        firstname: "Mahipal3",
        lastname: "Chavda",
        email: "Mahipal@gmail.com",
        phone: "7984172560",
        gender: "male",
        department: ".Net",
        skills: ["Programming"],
        about: "hello",
        id:5
    }, 
    {
        firstname: "manish3",
        lastname: "yadav",
        email: "manish@gmail.com",
        phone: "9104136213",
        gender: "male",
        department: "php",
        skills: ["Programming"],
        about: "this is good person",
        id:6
    },
    {
        firstname: "manishlast",
        lastname: "yadav",
        email: "manish@gmail.com",
        phone: "9104136213",
        gender: "male",
        department: "php",
        skills: ["Programming"],
        about: "this is good person",
        id:6
    }
]
let id = 0;
const checkId = () =>{
    if(Empdata.length==0){
        id=1;
    }else{
        id=Empdata[Empdata.length-1].id+1;
    }
}
const addData = (tempData) =>{
    checkId();
    tempData.id=id;
    Empdata.push(tempData);
}
const updatedata = (tempData) =>{
    let index = 0;
    for(let i=0;i<Empdata.length;i++){
        if(Empdata[i].id==tempData.id){
            index = i;
        }
    }
    Empdata[index] = tempData;
}
const paiginationFunction = (cp,ppi) =>{
    const ans = [];
    for(let i=cp*ppi;i<cp*ppi+ppi && i<Empdata.length;i++){
        ans.push(Empdata[i]);
    }
    return ans;
}
const sizeOfData = () =>{
    return Empdata.length;
}
export {updatedata}
export {paiginationFunction}
export {addData};
export {sizeOfData};
export default Empdata;