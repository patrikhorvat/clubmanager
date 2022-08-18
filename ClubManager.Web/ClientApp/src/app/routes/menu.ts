
const Home = {
    text: 'Kontrolna ploča',
    link: '/home',
    icon: 'icon-home'
};

const headingMain = {
    text: 'Glavni izbornik',
    heading: true
};

const players = {
  text: 'Igrači',
  link: '/employees/players',
  icon: 'fas fa-bullseye'
};

const trainers = {
  text: 'Treneri',
  link: '/employees/coaches',
  icon: 'fas fa-hand-holding'
};

const employees = {
  text: 'Svi zaposlenici',
  link: '/employees/overview',
  icon: 'fas fa-users'
};

const asset = {
  text: 'Imovina',
  link: '/asset/overview',
  icon: 'fas fa-box'
};

const teams = {
  text: 'Timovi',
  link: '/team/overview',
  icon: 'fas fa-building'
};

export const menu = [
    headingMain,
  Home,
  teams,
  players,
  trainers,
  employees,
    asset
];
