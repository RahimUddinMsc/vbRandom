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


