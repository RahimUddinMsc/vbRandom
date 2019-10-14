let btn = document.querySelector(".hidden")
let nav = document.querySelector(".nav")
let side = document.querySelector(".side-bar")
let main = document.querySelector(".main-content")


console.log(main)

btn.addEventListener('click', function(){
    if(nav.style.display === 'none'){
        nav.style.display = 'block';     
        side.style.display = 'block';
        nav.style.animation = "move-nav-bar-in 500ms 10ms ease-in forwards"
        side.style.animation = "move-side-bar-in 500ms 20ms ease-in forwards"
        main.style.animation = "move-content-mini 500ms 30ms ease-in forwards"                         
    }else{
        nav.style.animation = "move-nav-bar-out 500ms 10ms ease-out forwards"           
        main.style.animation = "move-content-full 500ms  20ms ease-out forwards"       
        side.style.animation = "move-side-bar-out 500ms 30ms ease-out forwards"           
        setTimeout(function(){
            nav.style.display = 'none';
            side.style.display = 'none';            
        },500)                        
    }    
})

nav.addEventListener('animationend',function(){    
    nav.style.animation = ''
    
})

side.addEventListener('animationend',function(){    
    side.style.animation = ''
    
})

main.addEventListener('animationend',function(){    
    main.style.animation = ''    
    main.classList.toggle('main-content-mini');
    main.classList.toggle('main-content-full');
})


let backdrop = document.querySelector(".backdrop")
let optionClose = document.querySelector(".option-close-icon")
let optionDipOpen = document.querySelector(".option-dipmain-search")

backdrop.addEventListener('click',toggleOptionModal)
optionClose.addEventListener('click',toggleOptionModal)
optionDipOpen.addEventListener('click',function(){
    //alert('clicked')
    document.querySelector('.context-modal').classList.add('context-modal-with-footer')
    setTimeout(function(){
        document.querySelector('.loader-mini').style.display = "none";    
        let labels = document.querySelectorAll('.dip-select label');    
        for(i = 0; i < labels.length; i++){
            labels[i].style.display = 'block';
        }
        document.querySelector('.option-dipmain-confirm-dip').style.display = 'inline'
        
    },2000)
    
})


//handle right button click
document.getElementById("test").onmousedown = function(e) {
    toggleOptionModal()
}


function toggleOptionModal(){
    document.querySelector('.backdrop').classList.toggle('open-backdrop');
    document.querySelector('.context-modal').classList.toggle('open-options-modal');        
    document.querySelector('.modal-dip-container').classList.remove('open-options-modal');        
}

//start with the backdrop set a time out and then start transition
setTimeout(togglePageLoadAnimations, 1000);

function togglePageLoadAnimations(){
    document.querySelector('.inflow-heading').classList.toggle('loader-trans')
    document.querySelector('.outflow-heading').classList.toggle('loader-trans')
    document.querySelector('.seperator').classList.toggle('loader-trans')
}

setTimeout(function(){
    togglePageLoadAnimations()
    setTimeout(function(){
        document.querySelector('.loading-backdrop').style.display = "none";    
    },1000)
    
    
}, 1000);

 

//function killNav(){
//    nav.style.display = 'none'
//    side.style.display = 'none'
//
//    setTimeout(function(){
//        nav.classList.toggle('close')
//        side.classList.toggle('close')
//        
//    },1000)
//        main.classList.toggle('main-content')
//    
//}
//
//function explodeNav(){
//    nav.style.display = 'block'
//    side.style.display = 'block'
//    setTimeout(function(){
//        nav.classList.toggle('close')
//        side.classList.toggle('close')        
//    },500)
//        main.classList.toggle('main-content')
//    
//    
//}


