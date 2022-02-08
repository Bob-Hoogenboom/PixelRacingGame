### Introduction
I got inspired by Mario Kart Tour on mobile and i wanted to challenge myself by recreating Donkey Kong JR. and mario SNES style from that game. 

### DevLog part \#1 (09/02/2022)
<!-- what do i want? how did i get there? final result (gif/image)-->

First thing i did for this project was make a new Unity 3D 2020 URP project and import the sprites i got from MK-Tour. I wanted to make DKJR first because he is my favorite character of the 2 in MK-Tour. I also had a Voxel art model of the classic pipeframe from a previous project so i imported that onje into Magicavoxel to change the color to yellow to match DKJR. 
after having everything i need i started making a script in which DKJR's sprites always look purpendicular to the camera. Because i dont want to see a paper thin DKJR.
After making a billboard script i found an asset that was very old and very hardcoded but it did the basic of what i wanted to acomplish. It took 8 sprites and displayed them according to the angle of the camera and the player. I refactored a lot of the code and made it work with a scriptable object. The scriptable object holds sprites and the angle the sprite is connected to. if the camera is closest to one of the angels it displays the sprite the angle is set to. And after 1 week of work refactoring the code i finally got DKJR to spin. Now it was time to make him also spin when the kart was turning. I also had some trouble with it but the answer was easier then i thought. I subtracted the angle of the kart of the angel of the player sprite and made an if statement that would set the total angel back to 360 or 0 respectively. and after that i finished with this as result:

![DKJRPipeFrame](https://user-images.githubusercontent.com/55579218/153087294-77ba1aaa-e8c1-454f-8c47-82de902af81c.gif)

<!-- add this project to portfolio*-->
[My Portfolio](https://bobbymakesgames.com/)


