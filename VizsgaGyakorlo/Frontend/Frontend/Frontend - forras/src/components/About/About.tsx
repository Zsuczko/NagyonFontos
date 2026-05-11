import styles from './About.module.css'
import envelope from '../../assets/icons/envelope.svg'
import chat from '../../assets/icons/chat.svg'
import firework from '../../assets/icons/firework.svg'
import AboutCard from './AboutCard'


const About = () => {
  return (
    <section className={styles.about}>
        <p>A Kapocs.hu egy olyan randioldal, amely segít az embereknek új kapcsolatokat kialakítani. Az oldal célja, hogy könnyedén összehozza azokat, akik közös érdeklődési körrel rendelkeznek, és szeretnének új emberekkel megismerkedni. A felhasználók egyszerűen regisztrálhatnak, és személyre szabott profilokat hozhatnak létre, amelyek tükrözik egyedi preferenciáikat. Az oldal biztonságos és barátságos környezetet biztosít, így mindenki kényelmesen kapcsolatba léphet másokkal.</p>

        <div className='aboutCards'>
            <AboutCard icon={envelope} title={"Társkereső oldal"} description={"Könnyedén találhatsz értékes kapcsolatokat olyan emberekkel, akik hozzád hasonlóan gondolkodnak."}/>
            <AboutCard icon={chat} title={"Ismerkedj online"} description={"Egy beszélgetésből akár barátság vagy szerelem is születhet. Hidd el, lehetséges!"}/>
            <AboutCard icon={firework} title={"A te lehetőséged"} description={"Itt az alkalom, hogy rátalálj a barátságra vagy a szerelemre. Ez az oldal éppen ezért jött létre!"}/>
        </div>
    </section>
  )
}

export default About