import logo from '../../assets/icons/main.svg'
import styles from './Hero.module.css'

import googleplay from '../../assets/googleplay.png'
import appstore from '../../assets/appstore.png'
import Heads from './Heads'

const Hero = () => {
    return (
        <section className={styles.hero}>
            <img className={styles.backgroundLogo} src={logo} alt="Színes logo" />
            <Heads/>
            <h1>Kapocs.hu</h1>
            <p>Ismerj meg új embereket és találd meg azt, akivel igazán összekapcsolódsz! Nálunk a beszélgetések könnyedén indulnak, és a kapcsolatok természetesen alakulnak. Csatlakozz most, és lépj egy új élmény felé!</p>

            <div>
                <h2>{Math.floor(Math.random()*5000 + 3000)}</h2>
                <h3>online tag</h3>
            </div>

            <a href="#" className={styles.joinBtn}>Csatlakozok</a>

            <div className={styles.buttons}>
                <a href="#"><img src={googleplay} alt="GooglePlay logo" /></a>
                <a href="#"><img src={appstore} alt="AppStore logo" /></a>
            </div>

        </section>
    )
}

export default Hero