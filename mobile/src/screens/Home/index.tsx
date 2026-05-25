import * as S from './styles';
import { ScrollView } from 'react-native';
import { GalleryCard } from '../../components/GalleryCard';
import Ionicons from 'react-native-vector-icons/Ionicons';
import Logo from '../../components/Logo';

const data = [
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
  {
    title: 'Sala de Aula',
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua',
  },
];

export default function Home() {
  return (
    <S.Container>
      <ScrollView
        showsVerticalScrollIndicator={false}
        // Logo = 0, HelloText = 1, StickyHeaderContainer = 2
        stickyHeaderIndices={[2]} 
      >
        <Logo />

        <S.HelloText>Olá, Allan</S.HelloText>

        {/* --- CABEÇALHO FIXO (Índice 2) --- */}
        <S.StickyHeaderContainer>
          <S.Header>
            <S.GalleryTitle>Galeria</S.GalleryTitle>
            <Ionicons
              name="search-outline"
              size={28}
              color="black"
            />
          </S.Header>
        </S.StickyHeaderContainer>

        {/* --- LISTA DE CARDS (Índice 3) --- */}
        <S.GalleryItemsContainer>
          {data.map((item, index) => (
            <GalleryCard
              key={index} // Adicionado 'key' para evitar avisos (warnings) do React
              title={item.title}
              description={item.description}
            />
          ))}
        </S.GalleryItemsContainer>

      </ScrollView>
    </S.Container>
  );
}