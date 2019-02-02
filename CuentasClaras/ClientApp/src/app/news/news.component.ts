import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {

  public news = [
    {
      img:'https://mdbootstrap.com/img/Photos/Others/images/49.jpg',
      title: 'Titulo de la Nota',
      summary: 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, psam voluptatem quia consectetur.',
      author: 'Jessica Clark',
      date: '12/04/2018'
    },
    {
      img:'https://mdbootstrap.com/img/Photos/Others/images/31.jpg',
      title: 'Titulo de la Nota',
      summary: 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, psam voluptatem quia consectetur.',
      author: 'Jessica Clark',
      date: '12/04/2018'
    },
    {
      img:'https://mdbootstrap.com/img/Photos/Others/images/52.jpg',
      title: 'Titulo de la Nota',
      summary: 'Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, psam voluptatem quia consectetur.',
      author: 'Jessica Clark',
      date: '12/04/2018'
    }
  ];

  constructor() {
  }

  ngOnInit() {
  }

}
