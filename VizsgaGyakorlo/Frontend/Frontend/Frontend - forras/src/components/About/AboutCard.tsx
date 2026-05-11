
import styles from './About.module.css'

type AboutCardType = {
    icon: string,
    title: string,
    description: string
}

const AboutCard = (props: AboutCardType) => {
  return (
    <div className={styles.aboutCard}>
        <div><img src={props.icon} alt="icon" className={styles.icon}/></div>
        <h3 className={styles.title}>{props.title}</h3>
        <hr />
        <p className={styles.description}>{props.description}</p>
    </div>
  )
}

export default AboutCard