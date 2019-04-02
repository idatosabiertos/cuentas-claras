import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent {
  @Input() public post;

  public get hasImage() {
    return this.post && this.post.thumbnail
      && !/.*medium\.com\/_\/stat\?event=post.clientViewed&referrerSource=full_rss&postId=.*/.test(this.post.thumbnail)
  }

  public get summary() {
    if (this.post && this.post.description) {
      const str = this.post.description.replace(/<\/?[^>]+(>|$)/g, "");
      return str.trim().substring(0, Math.min(str.length, 500)) + '...';

    }
    return this.post.description;
  }

}
