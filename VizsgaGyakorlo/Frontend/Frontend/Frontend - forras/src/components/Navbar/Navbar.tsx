import logo from "../../assets/icons/main.svg"
import styles from "./Navbar.module.css"

const Navbar = () => {
  return (
    <nav className={styles.navbar}>
        <div>
            <a href="#"><img src={logo} alt="Színes logo" /></a>

            <div>
                <ul className="navbarLinks">
                    <li><a href="#">Rólunk</a></li>
                    <li><a href="#">Applikáció</a></li>
                    <li><a href="#">Kapcsolat</a></li>
                </ul>

                <div>
                    <a href="#">Bejelentkezés</a>
                    <a href="#">Regisztráció</a>
                </div>
            </div>
        </div>
    </nav>
  )
}

export default Navbar