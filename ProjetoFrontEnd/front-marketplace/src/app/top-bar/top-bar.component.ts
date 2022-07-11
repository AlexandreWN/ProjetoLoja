import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {


  @Input() titulo = ""
  constructor(private router:Router) { }

  ngOnInit(): void {
  }


  signOut(){
    localStorage.removeItem('authToken');
  }
}
