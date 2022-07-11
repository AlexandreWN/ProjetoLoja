import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  logado : boolean | null 
  tipoLogin : boolean | null 

  @Input() titulo = ""
  constructor(private router:Router) { }

  ngOnInit(): void {
    this.reset()
    this.typeLogin()
  }

  reset(){
    if(localStorage.getItem('authToken')== null){
      this.logado = false
    }
    else{
      this.logado = true
    }
  }

  typeLogin(){
    if(localStorage.getItem('tipoDeLogin')=="Client"){
      this.tipoLogin = true
    }
    else{
      this.tipoLogin = false
    }
  }

  signOut(){
    localStorage.removeItem('authToken');
  }
}
