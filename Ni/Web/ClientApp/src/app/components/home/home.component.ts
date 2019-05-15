import { Component } from '@angular/core';
import {AppStateService} from '../../services/app-state/app-state.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor (public appStateService: AppStateService) {
    this.appStateService = appStateService;
  }
}
