import * as S from './styles'

type Props = {
    name: string,
    onClick: () => void,
}

export default function CustomButton({ name , onClick}: Props){
    return(
        <S.Container
            onPress={onClick}
        >
            <S.ButtonText>
                {name}
            </S.ButtonText>
        </S.Container>
    );
}