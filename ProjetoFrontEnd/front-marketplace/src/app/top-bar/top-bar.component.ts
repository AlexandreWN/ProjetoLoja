import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  logado : boolean | null 

  @Input() titulo = ""
  constructor(private router:Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('authToken')== null){
      this.logado = false
    }
    else{
      this.logado = true
    }
  }

  reset(){
    if(localStorage.getItem('authToken')== null){
      this.logado = false
    }
    else{
      this.logado = true
    }
  }

  signOut(){
    localStorage.removeItem('authToken');
  }
}
