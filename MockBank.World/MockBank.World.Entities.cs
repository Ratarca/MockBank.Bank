namespace MockBank.World.Entities{


public record Person(int id, int born, Gender gender,string name, 
                    Countries country , States state, FlagParents flagParents,
                    float familyIncome,EducationLevel educationLevel,
                    Work Work, float Income);

public enum Gender{
    female = 0,
    male = 1,
}

public enum Countries{
    brazil,
}

public enum States{
    maranhao,
    amapa,
    tocantins,
    ceara,
    bahia,
    sao_paulo,
    hell_de_janeiro,
    minas_gerais,
    goias,
    parana,
    

}

public enum FlagParents{
    notParent = 0,
    hasParent = 1,

}

public enum EducationLevel{
    low,
    medium,
    high,
    extreme
}

public enum Work{
    notWorking = 0,
    working = 1,

}

};