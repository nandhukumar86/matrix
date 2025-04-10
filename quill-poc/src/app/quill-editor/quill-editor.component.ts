import { Component, ElementRef, ViewChild, AfterViewInit, Output, EventEmitter } from '@angular/core';
import Quill from 'quill';

@Component({
  selector: 'app-quill-editor',
  standalone: false,
  templateUrl: './quill-editor.component.html',
  styleUrls: ['./quill-editor.component.scss']
})
export class QuillEditorComponent implements AfterViewInit {
  @ViewChild('editor') editorElement!: ElementRef;
  @Output() contentChanged = new EventEmitter<string>();
  characterCount: number = 0;

  quill!: Quill;

  ngAfterViewInit(): void {
    this.quill = new Quill(this.editorElement.nativeElement, {
      theme: 'snow',
      placeholder: 'Write something...',
      modules: {
        toolbar: [
          ['bold', 'italic', 'underline'],
          [{ list: 'ordered' }, { list: 'bullet' }],
          ['link', 'image']
        ]
      }
    });

    this.quill.on('text-change', () => {
      const text = this.quill.getText();
      const delta = this.quill.getContents();

      this.characterCount = this.calculateCustomCharacterCount(text, delta);
      this.contentChanged.emit(this.quill.root.innerHTML);
    });
  }

  // calculateCustomCharacterCount(text: string, delta: any): number {
  //   const baseLength = text.replace(/\n/g, '').trim().length;
  //   const newlineCount = (text.match(/\n/g) || []).length;
  //   let listItemCount = 0;

  //   delta.ops.forEach((op: any) => {
  //     if (op.attributes?.list === 'bullet' || op.attributes?.list === 'ordered') {
  //       listItemCount++;
  //     }
  //   });

  //   const newlineBonus = newlineCount * 2;
  //   const listBonus = listItemCount * 5;

  //   return baseLength + newlineBonus + listBonus;
  // }

  calculateCustomCharacterCount(text: string, delta: any): number {
    // Treat the editor as empty if it only has Quill's default '\n'
    const isEmpty = text === '\n' || text.trim() === '';

    if (isEmpty) {
      return 0;
    }

    // Base character count excluding newlines
    const baseLength = text.replace(/\n/g, '').length;

    // Count user-entered newlines (subtract the default one)
    const totalNewlines = (text.match(/\n/g) || []).length;
    const userNewlines = Math.max(0, totalNewlines - 1); // 👈 This line is key
    const newlineBonus = userNewlines * 2;

    // Count list items (ordered or bullet)
    let listItemCount = 0;

    if (delta && Array.isArray(delta.ops)) {
      for (const op of delta.ops) {
        if (op.attributes?.list === 'bullet' || op.attributes?.list === 'ordered') {
          listItemCount++;
        }
      }
    }

    const listBonus = listItemCount * 3;

    return baseLength + newlineBonus + listBonus;
  }





  onContentUpdate(content: string) {
    console.log('Editor content:', content);
  }

}
