import { Component, OnInit } from '@angular/core';
import { ChangeTrackerService } from '../services/change-tracker.service';

@Component({
  selector: 'lib-change-tracker',
  template: ` <p>change-tracker works!</p> `,
  styles: [],
})
export class ChangeTrackerComponent implements OnInit {
  constructor(private service: ChangeTrackerService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
