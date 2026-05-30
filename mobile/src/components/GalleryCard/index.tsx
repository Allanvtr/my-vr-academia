import * as S from './styles';

type Props = {
  title: string;
  description: string;
  onClick: () => void;
};

export function GalleryCard({ title, description, onClick }: Props) {
  return (
    <S.Container
      onPress={onClick}
    >
      <S.CardImage />

      <S.TextContainer>
        <S.Title>{title}</S.Title>
        <S.Description>{description}</S.Description>
      </S.TextContainer>
    </S.Container>
  );
}