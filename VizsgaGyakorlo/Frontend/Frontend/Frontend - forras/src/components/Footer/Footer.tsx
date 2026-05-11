import logo from '../../assets/icons/white.svg'
import googleplay from '../../assets/googleplay.png'
import appstore from '../../assets/appstore.png'
import facebook from '../../assets/icons/facebook.svg'
import styles from './Footer.module.css'

const Footer = () => {
  return (
    <footer className={styles.footer}>
        <img src={logo} alt="Fehér logo" />
        <div className={styles.appButtons}>
            <a href="#"><img src={googleplay} alt="GooglePlay" /></a>
            <a href="#"><img src={appstore} alt="AppStore" /></a>
        </div>

        <ul>
            <li><a href="#">Rólunk</a></li>
            <li><a href="#">Applikáció</a></li>
            <li><a href="#">Kapcsolat</a></li>
        </ul>

        <a href="#"><img src={facebook} alt="Facebook" /></a>

        <p>© Copyright - Kapocs.hu</p>
    </footer>
  )
}

export default Footer