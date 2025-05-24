//setac1.1
//setac pocinje uvijek iz lokacije sa id=box15
var trenutnaLokacija = document.getElementById('box15');
trenutnaLokacija.classList.add('walker');

var novi, konvertovan;

function poruka() {
    var sansa = Math.floor(Math.random() * 32) + 1;
    var uzmi = document.getElementById('poruka');
    console.log(sansa);
    switch (sansa) {
        case 1: uzmi.innerHTML = 'Ne mogu tamo.'; break;
        case 2: uzmi.innerHTML = 'Gdje su mi kljucevi'; break;
        case 3: uzmi.innerHTML = 'Do kada cemo ovako?'; break;
        case 4: uzmi.innerHTML = 'Vidim zgradu FIT-a odavde.'; break;
        case 5: uzmi.innerHTML = 'Dobro mi dodje ova pauza.'; break;
        case 6: uzmi.innerHTML = 'Al\' sam se nahodao...'; break;
        case 7: uzmi.innerHTML = 'Neka nevidljiva sila mi brani...'; break;
        case 8: uzmi.innerHTML = 'Koliko ima odavde do mora?'; break;
        case 9: uzmi.innerHTML = 'Lorem ipsum itd. itd...'; break;
        case 10: uzmi.innerHTML = 'Homo homini lupus est.'; break;
        case 11: uzmi.innerHTML = 'K\'o rano rani...'; break;
        case 12: uzmi.innerHTML = 'K\'o drugom jamu kopa...'; break;
        case 13: uzmi.innerHTML = 'Ne hoda mi se vise.'; break;
        case 14: uzmi.innerHTML = 'Gdje dodje najblizi Bingo?'; break;
        case 15: uzmi.innerHTML = 'Veni, vidi, vici.'; break;
        case 16: uzmi.innerHTML = 'Heeeeey Macarena!'; break;
        case 17: uzmi.innerHTML = 'Dosao sam da ti kazem da odlazim.'; break;
        case 18: uzmi.innerHTML = 'Dodje mi da vrisnem.'; break;
        case 19: uzmi.innerHTML = 'Gdje sam ono krenuo?'; break;
        case 20: uzmi.innerHTML = 'Umorih se.'; break;
        case 21: uzmi.innerHTML = 'Konja, konja, dajem kraljevstvo za jednoga konja!'; break;
        case 22: uzmi.innerHTML = 'Hajdemo u planine...'; break;
        case 23: uzmi.innerHTML = 'Ubise me cipele.'; break;
        case 24: uzmi.innerHTML = 'Dotak\'o sam dno zivota.'; break;
        case 25: uzmi.innerHTML = 'Ne vidim svrhu ovoga.'; break;
        case 26: uzmi.innerHTML = 'Mislim da me neko prati.'; break;
        case 27: uzmi.innerHTML = 'Pratim te...'; break;
        case 28: uzmi.innerHTML = 'Ovo se otelo kontroli.'; break;
        case 29: uzmi.innerHTML = 'Pamti, pa vrati.'; break;
        case 30: uzmi.innerHTML = 'Od zida, do zida...'; break;
        case 31: uzmi.innerHTML = 'Da li je casa poluprazna ili napola puna?'; break;
        case 32: uzmi.innerHTML = 'Gdje mi je mobitel?'; break;
        
        default:
            break;
    }
}

function vracajSetaca(){
    const staraPoz = 'box' + konvertovan;                   //kreira 'id' stare pozicije prije izlaska iz okvira
    trenutnaLokacija = document.getElementById(staraPoz);   //odredjuje da je ta pozicija opet trenutna pozicija
    trenutnaLokacija.classList.add('walker');               //dodjeluje div-u na toj poziciji klasu 'walker'
    var p = document.getElementById('poruka');
    p.style.display = 'block';
    poruka();
    setTimeout(function(){ p.style.display = 'none'; }, 1000);
   }

function setacNastavlja() {
    const novaPoz = 'box' + novi;                           //spajanjem kreira id div-a koji ce biti nova pozicija setaca
    trenutnaLokacija = document.getElementById(novaPoz);    //poziva se taj element
    trenutnaLokacija.classList.add('walker');               //dodjeluje div-u na toj poziciji klasu 'walker' 
}

// idi gore

const up = document.getElementById('up');           
up.addEventListener('click', setanjeGore);          //dugme 'up' pokrece funkiju kad se klikne na njega
function setanjeGore() {
    const koord = trenutnaLokacija.id;              //saznaje id setaca 
    const broj = koord.slice(3, 5);                 //izdvaja samo broj iz id-a setaca
    trenutnaLokacija.classList.remove('walker');    //brise setaca sa trenutne lokacije
    konvertovan = Number(broj);                     //konvertuje iz stringa u broj
    novi = konvertovan - 6;                         //minus 6 jer je 'setanjeGore' funkcija u pitanju   
    if (novi < 1) {
        //vracanje setaca nazad na polje
        vracajSetaca();  
    } 
    else
    {
        //setac ne izlazi iz okvira
        setacNastavlja();
    }   
}

// idi desno

const right = document.getElementById('right');
right.addEventListener('click', setanjeDesno);      //dugme 'right' pokrece funkiju kad se klikne na njega
function setanjeDesno() {
    const koord = trenutnaLokacija.id;              //saznaje id setaca  
    const broj = koord.slice(3, 5);                 //izdvaja samo broj iz id-a setaca
    trenutnaLokacija.classList.remove('walker');    //brise setaca sa trenutne lokacije
    konvertovan = Number(broj);                     //konvertuje iz stringa u broj
    novi = konvertovan + 1;                         //plus 1 jer je 'setanjeDesno' funkcija u pitanju  
    if (novi%6 === 1) {
        //vracanje setaca nazad na polje
        vracajSetaca();
    }  
    else
    {
        //setac ne izlazi iz okvira
        setacNastavlja();
    }  
}

// idi dole

const down = document.getElementById('down');      
down.addEventListener('click', setanjeDole);        //dugme 'down' pokrece funkiju kad se klikne na njega
function setanjeDole() {
    const koord = trenutnaLokacija.id;              //saznaje id setaca
    const broj = koord.slice(3, 5);                 //izdvaja samo broj iz id-a setaca
    trenutnaLokacija.classList.remove('walker');    //brise setaca sa trenutne lokacije
    konvertovan = Number(broj);                     //konvertuje iz stringa u broj
    novi = konvertovan + 6;                         //plus 6 jer je 'setanjeDole' funkcija u pitanju    
    if (novi > 36) {
       //vracanje setaca nazad na polje
       vracajSetaca();
    }   
    else
    {
        //setac ne izlazi iz okvira
        setacNastavlja();
    }  
}

// idi lijevo

const left = document.getElementById('left');
left.addEventListener('click', setanjeLijevo);      //dugme 'left' pokrece funkiju kad se klikne na njega
function setanjeLijevo() {
    const koord = trenutnaLokacija.id;              //saznaje id setaca   
    const broj = koord.slice(3, 5);                 //izdvaja samo broj iz id-a setaca
    trenutnaLokacija.classList.remove('walker');    //brise setaca sa trenutne lokacije
    konvertovan = Number(broj);                     //konvertuje iz stringa u broj
    novi = konvertovan - 1;                         //minus 1 jer je 'setanjeLijevo' funkcija u pitanju  
    if (novi%6 === 0) {
       //vracanje setaca nazad na polje
       vracajSetaca();
    }   
    else
    {
        //setac ne izlazi iz okvira
        setacNastavlja();
    }   
}
