import man1 from '../../assets/img/man1.jpg'
import man2 from '../../assets/img/man2.jpg'
import man3 from '../../assets/img/man3.jpg'

import woman1 from '../../assets/img/woman1.jpg'
import woman2 from '../../assets/img/woman2.jpg'
import woman3 from '../../assets/img/woman3.jpg'
import woman4 from '../../assets/img/woman4.jpg'

import styles from './Heads.module.css'

type ImageDiskType = {
    img: string,
    isMale: boolean
}

const Heads = () => {

    let images: ImageDiskType[] = [{
        img: man1,
        isMale: true
    }, {
        img: man2,
        isMale: true
    }, {
        img: man3,
        isMale: true
    }, {
        img: woman1,
        isMale: false
    }, {
        img: woman2,
        isMale: false
    }, {
        img: woman3,
        isMale: false
    }, {
        img: woman4,
        isMale: false
    }]

    images = [...images, ...images, ...images]

    images = images.sort(() => Math.random() - 0.5)

  return (
    <div className={styles.heads}>
        {images.map((image, index) =>  <img key={index} src={image.img} style={
            {
                borderColor: image.isMale ? 'var(--male-blue)' : 'var(--female-pink)',
                marginLeft: `${Math.random()*1000 + 300}px`,
                animationDuration: `${Math.random()*10 + 10}s`,
            }
        }/> )}
    </div>
  )
}

export default Heads