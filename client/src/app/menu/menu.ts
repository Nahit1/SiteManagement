import { CoreMenu } from '@core/types'

export const menu: CoreMenu[] = [
  {
    id: 'home',
    title: 'Home',
    translate: 'MENU.HOME',
    type: 'item',
    icon: 'home',
    url: 'home'
  },
  {
    id: 'sample',
    title: 'Sample',
    translate: 'MENU.SAMPLE',
    type: 'item',
    icon: 'file',
    url: 'sample'
  },
  {
    id: 'apps',
    type: 'section',
    title: 'Tanımlamalar',
    icon: 'package',
    children: [
      {
        id: 'blocks',
        title: 'Bloklar',
        type: 'item',
        url: 'pages/block',
        icon: 'home',
        //openInNewTab: true
      }
    ]
  }

]