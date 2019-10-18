# Simple-MVC-Project
There is a simple mvc project. Code examples of many concepts are available. I used code first with entity framework 6 and MSSQL as the database. I stopped this project because I started a bigger project. Those who want to contribute can be found.  I'll be sharing it when my new project is over. Stay Tuned :) 

## Installation and Requirements
İf you want to develop a MVC project, I suggest microsoft platform such as ASP.Net. Here is link of Visual Studio. 
[Visual Studio](https://visualstudio.microsoft.com/tr/vs/) - Download


## Simple example of code
```bash
data
string1: .asciiz "Enter a number:"
string2: .asciiz "Enter the secon number:"
string3: .asciiz "Sum:"
endLine: .asciiz "\n"

.text
main:

	li $v0 , 4				#print string1 
	la $a0 , string1  
	syscall

	li $v0 , 5	 			#read integer
	syscall
	
	move $t0,$v0            #Girdiğimiz integer değeri temporary(geçici) değere akttardık.
	
	li $v0 , 4
	la $a0 , endLine        #Boşluk vermek için. 
	syscall
	
	li $v0 , 4
	la $a0 , string2        
	syscall
	
	li $v0 , 5
	syscall
	
	move $t1,$v0             
	
	li $v0 , 4
	la $a0 , string3
	syscall
	
	add $t2,$t1,$t0			#İki tane yazdığımız integer değerleri toplayıp $t2 temporary değere aktardık.s
	li $v0, 1			    #print integer
	move $a0, $t2			#Temporary değeri a0 a aktardık.
	syscall
	
		 
	li $v0, 10              #exit
	syscall
	


```


