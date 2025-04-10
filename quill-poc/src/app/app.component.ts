import { Component } from '@angular/core';
import Quill from 'quill';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'quill-poc';

  onContentUpdate(content: string) {
    console.log('Editor content:', content);
  }
}
